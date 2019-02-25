Shader "Custom/Background_1"
{
    Properties
    {
		_MainTex ("Texture", 2D) = "white" {}
		 _CutTex("Cutout (A)", 2D) = "white" {}
    }
    SubShader
    {
        Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard

        sampler2D _MainTex;
		sampler2D _CutTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			fixed4 c = tex2D(_CutTex, float2(IN.uv_MainTex.x + _Time.x, IN.uv_MainTex.y));
			o.Emission = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
