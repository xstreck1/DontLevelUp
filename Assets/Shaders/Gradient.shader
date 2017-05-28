// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/Gradient" {
	Properties{ 
		_Color("Low Color", Color) = (0.75,0.75,0,1)
		_Color2("Mid Color", Color) = (0,0.75,0,1)
		_Color3("Top Color", Color) = (0,0.75,0,1)
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
#pragma surface surf Standard fullforwardshadows
#pragma target 3.0

	struct Input {
		float3 worldPos;
	};

	fixed4 _Color;
	fixed4 _Color2;
	fixed4 _Color3;

	sampler2D _MainTex;

	void surf(Input IN, inout SurfaceOutputStandard o)
	{
		if (IN.worldPos.y < 1) {
			o.Albedo = lerp(_Color, _Color2, IN.worldPos.y);
		}
		else {		
			o.Albedo = lerp(_Color2, _Color3, (IN.worldPos.y - 1));
		}
	}
	ENDCG
	}
	FallBack "Diffuse"
	}