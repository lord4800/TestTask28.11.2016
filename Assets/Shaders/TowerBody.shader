Shader "Custom/TowerBody" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_SecondTex ("Albedo (RGB)", 2D) = "white" {}
		_ThirdTex ("Albedo (RGB)", 2D) = "white" {}


	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _SecondTex;
		sampler2D _ThirdTex;

		struct Input {
			float2 uv_SecondTex;
			float2 uv_ThirdTex;
		};

		fixed4 _Color;


		void surf (Input IN, inout SurfaceOutputStandard o) {

			fixed4 c = tex2D (_SecondTex, IN.uv_SecondTex) + tex2D (_ThirdTex, IN.uv_ThirdTex) + _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
