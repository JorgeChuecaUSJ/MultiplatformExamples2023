Shader "Custom/NewShaderCustom"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        [Toggle(DO_LIGHTING)] _DoLighting ("DoLighting inspector", Int) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma shader_feature DO_LIGHTING

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
            };

            fixed4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                //float3 worldPos = mul (unity_ObjectToWorld, v.vertex.xyz);
                //worldPos.y += sin( worldPos.x*5 + _Time.y*10 );
                //o.vertex = UnityObjectToClipPos(mul (unity_WorldToObject, worldPos));
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = mul(unity_ObjectToWorld, v.normal);
                return o;
            }

#if DO_LIGHTING
#define CalculateLight(normal) saturate(dot(normal, _WorldSpaceLightPos0)) * _LightColor0
#else
#define CalculateLight(normal) float4(1,1,1,1);
#endif

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = _Color;
                float4 light = CalculateLight(i.normal);
                col *= light;
                return col;
            }
            ENDHLSL
        }
    }
}
