// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/Gradient" {
	Properties{ 
		_Color("Low Color", Color) = (0.75,0.75,0,1)
		_Color2("Mid Color", Color) = (0,0.75,0,1)
		_Color3("Top Color", Color) = (0,0.75,0,1)
		_Scale("Scale", Float) = 144 // This is the width of the game plane in the world coordinates
		_Glossiness("Smoothness", Range(0,1)) = 0.5
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
#pragma surface surf Standard vertex:vert fullforwardshadows
#pragma target 3.0
		struct Input {
		float2 uv_MainTex;
		float3 vertexColor; // Vertex color stored here by vert() method
	};

	struct v2f {
		float4 pos : SV_POSITION;
		fixed4 color : COLOR;
	};


	fixed4 _Color;
	fixed4 _Color2;
	fixed4 _Color3;
	fixed  _Scale;


	void vert(inout appdata_full v, out Input o)
	{
		UNITY_INITIALIZE_OUTPUT(Input, o);
		float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
			o.vertexColor = lerp(_Color, _Color2, worldPos.y / 2);
		
	}

	sampler2D _MainTex;

	half _Glossiness;
	half _Metallic;

	void surf(Input IN, inout SurfaceOutputStandard o)
	{
		o.Albedo = IN.vertexColor;
		o.Smoothness = _Glossiness;
		o.Alpha = 1;
		o.Emission = half3(0,0,0);
	}
	ENDCG
	}
	FallBack "Diffuse"
	}