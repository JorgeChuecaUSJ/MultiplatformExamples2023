Shader"Custom/ConditionalColorShader"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        [Toggle(DEBUG_NORMALS)]_ToggleNormals("Toggle Normals", Float) = 0.0
        [Toggle(DO_LIGHTING)]_ToggleLighting("Toggle Lighting", Float) = 0.0
        [Toggle(DO_AMBIENT)]_ToggleAmbient("Toggle Ambient", Float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
		    #pragma shader_feature DEBUG_NORMALS
		    #pragma shader_feature DO_LIGHTING
		    #pragma shader_feature DO_AMBIENT

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 normal : TEXCOORD0;
            };

            fixed4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = mul(unity_ObjectToWorld, v.normal);
                return o;
            }

#if DO_LIGHTING
    #if DO_AMBIENT
        #define CalculateLight(normal, lightDir) saturate(dot(normal, lightDir) * _LightColor0) +unity_AmbientSky
    #else
        #define CalculateLight(normal, lightDir) saturate(dot(normal, lightDir) * _LightColor0)
    #endif
#else
    #define CalculateLight(normal, lightDir) 1.0
#endif

            fixed4 frag (v2f i) : SV_Target
            {
                float4 lighting = CalculateLight(i.normal, _WorldSpaceLightPos0);
                fixed4 col = _Color * lighting;
#if DEBUG_NORMALS
                col.rgb = i.normal;
#endif
    
                return col;
            }
            ENDHLSL
        }
    }
}
