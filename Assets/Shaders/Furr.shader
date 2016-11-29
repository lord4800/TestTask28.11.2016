Shader "Custom/Furr" {
	Properties {
		_FurLength ("Fur Length", Range(.0002, 1)) = .25
		_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
		_CutoffEnd ("Alpha cutoff end", Range(0,1)) = 0.5
		_EdgeFade ("Edge fade", Range(0,1)) = 0.4
		_Gravity ("Gravity direction", Vector) = (0,0,1,0)
		_GravityStrength ("Gravitystrenght", Range(0,1)) = 0.25
		_Color ("Gravity direction", color) = (1,1,1,1)
		_MainTex ("MainTex", 2D) = "white" {}
		_Glossiness ("Glossiness", Range(0,1)) = 1
		_Metallic ("Metallic", Range(0,1)) = 1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
		#define FUR_MULTIPLIER 0.95
		#include "FurPass.cginc"



		ENDCG
	}
	FallBack "Diffuse"
}
