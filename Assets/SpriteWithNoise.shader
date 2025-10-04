Shader "Custom/SpriteWithNoise"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _NoiseTex ("Noise Texture (RGB)", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _NoiseColor ("Noise Color", Color) = (0,0,0,1)
        _NoiseThreshold ("Noise Threshold", Range(0, 1)) = 0.5
        _NoiseIntensity ("Noise Intensity", Range(0, 1)) = 1.0
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
            "PreviewType" = "Plane"
            "CanUseSpriteAtlas" = "True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                float2 noise_uv : TEXCOORD1;
            };

            fixed4 _Color;
            fixed4 _NoiseColor;
            sampler2D _MainTex;
            sampler2D _NoiseTex;
            float4 _NoiseTex_ST;
            float _NoiseThreshold;
            float _NoiseIntensity;

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.noise_uv = TRANSFORM_TEX(IN.texcoord, _NoiseTex);
                OUT.color = IN.color * _Color;
                #ifdef PIXELSNAP_ON
                OUT.vertex = UnityPixelSnap(OUT.vertex);
                #endif

                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
{
    // Получаем цвет основного спрайта
    fixed4 spriteColor = tex2D(_MainTex, IN.texcoord) * IN.color;
    
    // Получаем значение шума
    fixed noiseValue = tex2D(_NoiseTex, IN.noise_uv).r;
    
    // Инвертируем: черный шум = 1, белый шум = 0
    fixed invertedNoise = 1.0 - noiseValue;
    
    // Плавный переход с использованием smoothstep
    fixed noiseMask = smoothstep(_NoiseThreshold - 0.1, _NoiseThreshold + 0.1, invertedNoise) * _NoiseIntensity;
    
    // Смешиваем цвет шума со спрайтом
    fixed4 finalColor = lerp(spriteColor, _NoiseColor, noiseMask);
    finalColor.a = spriteColor.a;
    
    return finalColor;
}
            ENDCG
        }
    }
}