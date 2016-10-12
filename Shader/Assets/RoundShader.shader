Shader "Custom/RoundShader" {
	Properties {
		//两种内容模式，图片模式
		_MainTex ("Base (RGB)", 2D) = "white" {}
		//纯色模式
		_MainColor ("Color", COLOR) = (1,1,1,1)
		//圆角半径，默认为0.1
		_RoundRadius("Radius",float) = 0.1
	}
	SubShader {
		
		Pass{
			CGPROGRAM

			#pragma fragment frag
			#pragma vertex vert
			#include "UnityCG.cginc"
			//获取3个属性 并传值到CG代码段
			sampler2D _MainTex;
			float _RoundRadius;
			float4 _MainColor;
			
			//片段着色器输入结构体(可省略)
			struct FragInput{
				float2 texcoord:TEXCOORD0;
			};
		struct vertexOutput {
			float4 pos : SV_POSITION;
			//由顶点着色器输出mesh信息中的纹理坐标，这个坐标是以对象为坐标系的
			float4 posInObjectCoords : TEXCOORD0;
		};
		vertexOutput vert(appdata_full input)
		{
			vertexOutput output;
			output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
			//直接把texcoord传递给片段着色器
			output.posInObjectCoords = input.texcoord;
			return output;
		}
			//片段着色器入口函数
			float4 frag(FragInput input) : COLOR
			{
				 
				
float4 c=tex2D(_MainTex,input.texcoord);//将图片信息按坐标转换成颜色
				//float4 c=_MainColor;	//纯色
				
				//x,y两个变元，区间均为[0,1]
				float x=input.texcoord.x;
				float y=input.texcoord.y;
				
				//4条直线的常数部分
				float xt=1-_RoundRadius;
				float xb=_RoundRadius;
				float yl=_RoundRadius;
				float yr=1-_RoundRadius;
				//如果(x,y)不在4条直线构成的矩形中(上图的白色区域)
				if(!(x<xt&&x>xb&&y>yl&&y<yr))
				{
				
					//如果(x.y)不在上图的绿色区域
					if(!((x<xt&&x>xb) || (y>yl&&y<yr) ))
						//数学不好，好像判断的复杂了，如果您可以直接写出紫色区域
						//的不等式组那么可以简单点
				{
				//计算四个顶点的坐标
				float2 plb=float2(_RoundRadius,_RoundRadius);
				float2 plt=float2(_RoundRadius,1-_RoundRadius);
				float2 prt=float2(1-_RoundRadius,1-_RoundRadius);
				float2 prb=float2(1-_RoundRadius,_RoundRadius);
			
				//计算x,y分别到4个顶点的距离
				float distlb=sqrt(pow((x-plb.x),2)+pow((y-plb.y),2));
				float distlt=sqrt(pow((x-plt.x),2)+pow((y-plt.y),2));
				float distrt=sqrt(pow((x-prt.x),2)+pow((y-prt.y),2));
				float distrb=sqrt(pow((x-prb.x),2)+pow((y-prb.y),2));
				
				//对4个距离取最小值
				float dist=min(distlb,distlt);
				dist=min(dist,distrt);
				dist=min(dist,distrb);
				
				//将大于半径的表面剔除
				if(dist>_RoundRadius)
						discard;

				}

				if(x>1||x<0||y>1||y<0)
				discard;
				
				
				}

				return c; 

			}
			ENDCG
		}

		
	} 
	FallBack "Diffuse"
}