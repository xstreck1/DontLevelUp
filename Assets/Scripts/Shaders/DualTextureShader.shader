// Unlit alpha - blended shader.
// - no lighting
// - no lightmap support
// - no per-material color

Shader "DuelVR/HolyArea" {
	Properties{
		_MainTex("Flames", 2D) = "white" {}
	_Mist("Mist", 2D) = "white" {}
	_Mist2("Mist2", 2D) = "white" {}
	_Speed("Speed", float) = 1
	}

		SubShader{
		Tags{ "Queue" = "Transparent"  "RenderType" = "Transparent" }
		LOD 100

		Cull Off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha


		CGPROGRAM
#pragma surface surf Lambert alpha
#pragma shader_feature _EMISSION

#include "UnityCG.cginc"

		struct Input {
		float2 uv_MainTex;
	};


	sampler2D _MainTex;
	sampler2D _Mist;
	float _Speed;
	sampler2D _Mist2;

	void surf(Input IN, inout SurfaceOutput o) {
		 
		float2 shiftF = float2(0., IN.uv_MainTex.y * (float)(sin(_Time * 5.) + 1) / 5.);
		float2 shiftM1 = float2((float)(_Time * -.9), (float)(_Time * .7)) *_Speed;
		float2 shiftM2 = float2((float)(_Time * .5), (float)(_Time * -1.2))*_Speed;
		float2 shiftM3 = float2((float)(_Time * -.3), (float)(_Time * -.9))*_Speed;
		float2 shiftM4 = float2((float)(_Time * 1.3), (float)(_Time * .1))*_Speed;
		//fixed4 mainCol = tex2D(_MainTex, IN.uv_MainTex - shiftF);
		//fixed4 mainCol1 = tex2D(_Mist, IN.uv_MainTex - shiftF);
		//fixed4 mainCol2 = tex2D(_Mist2, IN.uv_MainTex - shiftF);
		fixed4 col3 = tex2D(_MainTex, IN.uv_MainTex +shiftM1);
		fixed4 col4 = tex2D(_Mist, IN.uv_MainTex + shiftM2);
		fixed4 col2 = tex2D(_Mist2, IN.uv_MainTex + shiftM3);
		o.Albedo = (col2 + col3 + col4) / 3.0;
		o.Alpha = .5f;
		//o.Alpha = col3.a * mainCol.a * _AlfaEffect;
		//o.Alpha *= min(IN.uv_MainTex.y * 5 ,1);
		//o.Alpha *= min((1 - IN.uv_MainTex.y) * 5, 1);
		//o.Emission = lerp(_EmissionColor, _Color2, IN.uv_MainTex.y) * _Emission;
		//o.Albedo *= _Strength;
	}
	ENDCG
	}


		CustomEditor "HolyAreaGUI"
}
