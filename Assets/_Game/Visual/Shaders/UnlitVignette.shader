Shader "Custom/UIVignetteFlexible"
{
    Properties
    {
        _Color ("Vignette Color", Color) = (0,0,0,1)
        _Intensity ("Intensity", Range(0,5)) = 0
        _Radius ("Radius", Range(0,1)) = 0.007
        _Smoothness ("Smoothness", Range(0,1)) = 0.262
        _AspectRatio ("Aspect Ratio", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;
            float _Intensity;
            float _Radius;
            float _Smoothness;
            float _AspectRatio;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 center = float2(0.5, 0.5);

                // Коррекция по оси X для овальной формы
                float2 pos = i.uv - center;
                pos.x *= _AspectRatio;

                float dist = length(pos);

                // Градиент с плавной зоной
                float vignette = smoothstep(_Radius, _Radius + _Smoothness, dist) * _Intensity;

                return fixed4(_Color.rgb, vignette);
            }
            ENDCG
        }
    }
}
