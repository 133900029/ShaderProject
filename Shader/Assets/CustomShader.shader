Shader "Custom/CustomShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}//2d纹理 默认贴图名称为white
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Vector("Vector", Vector) = (0,0,0,0)
		_Float("Float", Float) = 0.1
		_Rect("Rect", Rect) = ""{}//矩形纹理
		_Cube("Cube", Cube) = ""{TexGen ObjectLinear}//立方体纹理
		//变量名  (显示名   ,  参数类型) = 默认值
		//变量名  (显示名   ,  参数类型) = 默认贴图名称{选项}
	
		_MainTex1 ("Albedo (RGB)", 2D) = "white" {}
	}

	//Category{

	//FOG{Mode Off}
	 
	//只找一个合适的subshader 都没有就用fallbcak
	SubShader {
				//通用状态，所有pass都需要
		        /*
				//Tags
				Tags { "RenderType"="Opaque" }
				//render setup
				LOD 200
				//texture setup 或者 surface
	 			CGPROGRAM
				//#pragma surface   surf       Standard fullforwardshadows
				//pragma surface 表面函数 光照模型[可选参数]
				#pragma target 3.0

				//变量需要定义
				//surface自动编译到各个pass
			    sampler2D _MainTex;//2D纹理贴图//uv贴图
				half _Glossiness;
				half _Metallic;


				//fixed：低精度浮点值  -2到2之间
				//half:中精度浮点值
				//float：高精度浮点值

				//fixed4 half4 float4 是4维变量


				fixed4 _Color;

				//输入  
				struct Input {//surface输入结构为uv+附加数据  //Input viewDir名字不能改
					float2 uv_MainTex;//uv坐标,必须要uv+贴图名
					float3 viewDir;//视觉方向
					float4 color:COLOR;//插值颜色
					float4 screenPos;//屏幕坐标
					float3 worldPos;//世界坐标
					float3 worldRefl;//世界坐标的反射向量
					float3 worldNormal;//世界坐标的法线向量
					//INTERNAL_DATA//当输入包括worldRefl或worldNormal  且输出包括  Normal 则需要声明	
				};

				//输出
				//struct SurfaceOutput{
				//	half3 Albedo;//反射光
				//	half3 Normal;//法线
				//	half3 Emission;//自发光
				//	half Specular;//高光
				//	half Gloss;//光泽度
				//	half Alpha;//透明度
				//}

				

				void surf (Input IN, inout SurfaceOutputStandard o) {//固定写法

					// Albedo comes from a texture tinted by color
					fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
					//o.Albedo = IN.viewDir;
					o.Albedo = c.rgb;//不赋值 albedo为 0
					// Metallic and smoothness come from slider variables
					o.Metallic = _Metallic;
					o.Smoothness = _Glossiness;
					o.Alpha = c.a;
					
					//o.Alpha = IN.viewDir;
				}
				ENDCG
				*/
				/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				//每个pass 都会执行
				Pass
				{
					//变量不用定义
					//这里放顶点着色器和像素着色器和固定功能
					//顶点程序会替换掉固定着色器的3d变换，光照
					//片段程序会替换掉固定着色器的SetTexture命令
					 
					//name and tags
					//Tags { "LightMode" = "ShadowCaster" }
					//render setup
					//Lighting On
					//texture setup
					//SetTexture[_MainTex1]{ }//CGPROGRAM

					CGPROGRAM
					 
					#pragma vertex vert 
					#pragma fragment frag
					#include "UnityCG.cginc"
					/*
					struct v2f{
						fixed4 color : COLOR;
					}*/
					
					//surface  输入是选其中固定的几个变量   输出也是选其中几个固定的变量
					//vertex   输入是选其中固定的几个变量   输出是自定义 或者 用inout修改数据
					//fragment 输入是自定义                 输出是固定的几个变量

		struct vertexOutput {
			//声明结构体的成员pos,类型为float类型的4元向量，语义为SV_POSITION,col同理;
			float4 pos :SV_POSITION;
			float3 color : COLOR;
		};
		//v2f 已经定义了
		//inputData和v2f都写成v
					vertexOutput vert(appdata_full inputData)//inout  可以修改//顶点着色器的输入
					{
				 
						vertexOutput v;
						inputData.vertex.xyz += inputData.normal *1;//没有frag 是不会显示  //inout 也没用
						v.pos = mul(UNITY_MATRIX_MVP,inputData.vertex);//不设置位置会看不到图形
						v.color = inputData.normal * 0.5 + 0.5;
					 
						return v;
 
					}  
					
					half4 frag(vertexOutput v):COLOR{
						return half4(v.color,1); 
					}
 


					ENDCG
				}

			
		 //C:\Users\Martin\Desktop\shader\DefaultResourcesExtra\Nature
		 //Shader "Nature/SpeedTree"
	}//SubShader
 
 

	//}//Category
	FallBack "Diffuse"
}
