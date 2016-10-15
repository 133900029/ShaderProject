Shader "Custom/Diffuse" {
	Properties {
		//材料颜色默认为黑色，可在inspector中调节
		_Color ("Material Color", Color) =  (1,1,1,1)
	}
	SubShader {
		//LightMode我们在后面会继续讨论
		Tags { "LightMode" = "ForwardBase" }
		
		Pass{
		CGPROGRAM
		// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
		//#pragma exclude_renderers gles
		//定义顶点着色器与片段着色器入口
		#pragma vertex vert 
		#pragma fragment frag
		//获取property中定义的材料颜色
		uniform float4 _Color; 
		
		// 光源的位置或者方向
		//uniform float4 _WorldSpaceLightPos0;
		
		
		// 光源的颜色 (from "Lighting.cginc")
		uniform float4 _LightColor0;

		
		//定义顶点着色器的输入参数结构体 
		//我们只需要每个顶点的位置与对应的法向量
		struct vertexInput {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};
		//定义顶点着色的输出结构体/片段着色的输入结构体
		//已经计算好的颜色
		struct vertexOutput {
			float4 pos : SV_POSITION;
			float4 col : COLOR;
		};
		
		

		//顶点着色器
		vertexOutput vert (vertexInput input) {
			vertexOutput output;
			//对象坐标系到世界坐标系的变换矩阵
			//_Object2World与_World2Object均为unity提供的内置uniform参数
			float4x4 modelMatrix = _Object2World;
			//世界坐标系到对象坐标系的变换矩阵
			float4x4 modelMatrixInverse = _World2Object;
			
			
			//计算对象坐标系中的顶点法向量的单位向量
			//将mesh传递过来的顶点法向量与模型-->对象坐标系矩阵相乘得到对象坐标系中的法向量
			//然后单位化

			float4 normal4 = float4(input.normal, 0.0);

			float3 modelDirection = float4(mul(normal4, modelMatrixInverse));
			float3 normalDirection = normalize(modelDirection);
			

			//计算入射向量的单位向量
			float3 lightDirection = normalize(float4(_WorldSpaceLightPos0));
			
			//计算反射后的颜色
			//先将光源颜色与材料颜色向量相乘
			//再乘以上文提到的max(0,cos∠(N,L))
			float cosDirection = dot(normalDirection, lightDirection);
			float3 diffuseReflection=float4(_LightColor0) * float4(_Color)* max(0.0, cosDirection);	
			
			//上面计算的是RGB颜色，差个A，补充一维就可以传递给片段着色器了	
			output.col=float4(diffuseReflection,1.0);
			
			//国际惯例，顶点变化三步曲，这个例子中可写可不写
			output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
			
			return output;
		}
		
		//片段着色器，老规矩，把顶点着色器的输出参数作为片段着色器的输入参数
		float4 frag(vertexOutput input): COLOR
		{
			return input.col;
		 
		}
		
		ENDCG
	}
}
}