

Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainColor("Main Color", Color) = (1, 1, 1, 1)
        _ShadingColor("Shading Color", Color) = (0, 0, 0, 0)
        _InkColor("Ink Color", Color) = (0, 0, 0, 0)
        _Shades("Shades", Range(5, 20)) = 5
        _DivideNormal("Divide Normal", Range(5, 300)) = 100
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100


        Pass
        {
            Cull Front       
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            float _DivideNormal;
            float _InkColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex + v.normal/_DivideNormal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return _InkColor;
            }
            ENDCG
        }

        Pass
        {            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
            };

            float4 _MainColor;
            float4 _ShadingColor;
            float _Shades;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float cosineAngle = dot(normalize(i.worldNormal), normalize(_WorldSpaceLightPos0.xyz));
                cosineAngle = max(cosineAngle, 0.6);
                cosineAngle = floor(cosineAngle * _Shades) / _Shades;
                // return _MainColor * cosineAngle;
                return lerp(_ShadingColor, _MainColor, cosineAngle);
            }
            ENDCG
        }
    }
}
