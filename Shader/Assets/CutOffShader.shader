Shader "Custom/CutOffShader" {
	SubShader 
	{
		Pass{
		Cull Off // 关掉裁剪模式，作用后面再说
		//Cull Front
		//Cull Back//默认
		//cull front 和back 是相对。
		 
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"
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
		float4 frag(vertexOutput input) : COLOR
		{
			//当坐标的y值大于0.5的时候擦除片段
			if (input.posInObjectCoords.y > 0.5)
			{
				discard; 
			}
			
			//其余部分仍然按y值大小生成经度绿色球
			return float4(0.0, input.posInObjectCoords.y , 0.0, 1.0); 
		}
		ENDCG
		} 
	}
}
