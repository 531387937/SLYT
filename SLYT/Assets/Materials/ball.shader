Shader "Custom/boll" {
		properties
		{
			_MainTex("my tex", 2D) = "white"{}
		_BumpTex("my bump",2D) = "bump"{}
		_RimColor("rim color",Color) = (0.26, 0.19, 0.13,0.0)
			_RimPower("rim power", Range(0.5, 8.0)) = 3.0
		}
			subshader
		{
			tags{ "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
#pragma surface surf Lambert

			sampler2D _MainTex;
		sampler2D _BumpMap;
		float4 _RimColor;
		float _RimPower;


		struct Input
		{
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float3 viewDir;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;

			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));      //获取法线值
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir),o.Normal));     //1
			o.Emission = _RimColor.rgb * pow(rim, _RimPower);
		}
		ENDCG
		}
			FallBack "Diffuse"
	}