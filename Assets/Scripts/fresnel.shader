Shader "Custom/Standard_FresnelOutline_Enhanced"
{
    Properties
    {
        _BaseColor("Base Color", Color) = (1,1,1,1)
        _OutlineColor("Outline Color", Color) = (0.2, 0.5, 1, 1)
        _OutlineThickness("Outline Thickness", Range(0.01, 0.1)) = 0.05
        _OutlineIntensity("Outline Intensity", Range(0, 5)) = 1.0
        _MinFresnel("Min Fresnel Intensity", Range(0, 1)) = 0.1 // Минимальная интенсивность Френеля
        _FresnelPower("Fresnel Power", Range(1, 5)) = 2.0 // Новая степень Френеля для усиления эффекта
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            Name "Outline"
            Cull Front
            ZWrite On
            ZTest LEqual

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
                float4 pos : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
                float3 worldViewDir : TEXCOORD1;
            };

            fixed4 _BaseColor;
            fixed4 _OutlineColor;
            float _OutlineThickness;
            float _OutlineIntensity;
            float _MinFresnel;
            float _FresnelPower;

            v2f vert(appdata v)
            {
                v2f o;
                float3 worldNormal = normalize(mul((float3x3)unity_ObjectToWorld, v.normal));

                // Смещаем вершины вдоль нормали для создания эффекта обводки
                o.pos = UnityObjectToClipPos(v.vertex + float4(worldNormal * _OutlineThickness, 0.0));
                o.worldNormal = worldNormal;
                o.worldViewDir = normalize(UnityWorldSpaceViewDir(v.vertex.xyz));
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Усиленный эффект Френеля с использованием степени для улучшения динамики
                float fresnel = max(_MinFresnel, pow(1.0 - saturate(dot(i.worldNormal, i.worldViewDir)), _FresnelPower));

                // Применяем цвет и яркость обводки с учётом минимального значения
                fixed4 outlineColor = _OutlineColor * fresnel * _OutlineIntensity;

                return outlineColor;
            }
            ENDCG
        }

        Pass
        {
            Name "Main"
            Cull Back
            CGPROGRAM
            #pragma vertex vertBase
            #pragma fragment fragBase
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            fixed4 _BaseColor;

            v2f vertBase(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 fragBase(v2f i) : SV_Target
            {
                return _BaseColor;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}