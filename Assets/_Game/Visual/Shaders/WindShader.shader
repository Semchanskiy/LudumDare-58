Shader "Unlit/WindShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _WindStrength ("Wind Strength", Range(0,0.5)) = 0.1
        _WindSpeed ("Wind Speed", Range(0,5)) = 1
        _WindFrequency ("Wind Frequency", Range(0,5)) = 1
        _PivotY ("Pivot Height", Float) = 0     // Usually 0 if pivot is at bottom
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _Color;
            float _WindStrength;
            float _WindSpeed;
            float _WindFrequency;
            float _PivotY;

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

            v2f vert(appdata v)
            {
                v2f o;
                float3 worldPos = v.vertex.xyz;

                // Height factor (0 at bottom, 1 at top)
                float heightFactor = saturate(worldPos.y - _PivotY);

                // Horizontal sway using sine wave
                float sway = sin(_Time.y * _WindSpeed + worldPos.x * _WindFrequency) * _WindStrength * heightFactor;

                // Shift only X axis
                worldPos.x += sway;

                o.vertex = UnityObjectToClipPos(float4(worldPos,1.0));
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv) * _Color;
            }
            ENDCG
        }
    }
}