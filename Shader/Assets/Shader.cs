using UnityEngine;
using System.Collections;

public class Shader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


//shader（着色器）是用来控制可编程图形渲染管线的程序
//GPU不同于CPU的运算结构，所以需要GPU的编程语言

//d3d & oepngl 是一个图形编程接口 ，对底层硬件的支持
//nvidia  & amd 是一个硬件显卡>gpu
//code -> d3d or opengl -> amd or nvidia


//1 微软开发基于direct3d的hlsl
//2 oepngl开发基于opengl的glsl
//3 nvidia开发基于direct3d和opengl的cg，cg与hlsl相似，cg同时兼容direct3d和opengl
//unity使用的是shaderlab 会针对平台进行编译，类似cg
//可以编写3种着色器。1 表面着色器，2顶点和片段着色器，3固定功能管线着色器
//                   1 surface shader 2 vertex and fragment shader 3 fixed function shader
//                   1 用shaderlab写，可以使物体接受阴影，简化代码
//                   2 相当于原生cg着色器

 



//普通 normal:用于不透明对象
//透明 transparent：用于半透明和全透明对象
//透明镂空 transparentcutout：用于完全透明和完全不透明的对象，例如 栅栏
//自发光 self-illuminated shader family：自发光对象
//反射 reflective shader family：用于反射环境的不透明对象


//光照：
//顶点光照     普通      凸起       视差凸起

//standardShader

//编写shader 需要 opengl和direct3d 渲染状态的了解，固定功能渲染管线，可编程管线，cg，hlsl，glsl编程语言，在nvidia和amd 网站






//渲染(rendering)：计算机根据模型(model)创建图像的过程。
//着色器（shader）
//模型(model)：根据几何图元创建的物体(object)。








//OpenGL的固定功能管线


//片元=片段=像素

//关于渲染管线将什么呢?无非就是在OpenGL的管道当中各个部分的功能以及如何在管道当中形成了我们想要的最终的一幅图.(像素).

//1指定几何对象（输入简单的顶点属性）
//a 一次一个顶点.即使用glBegin()  glVertex() glEnd() 指定几何对象.
//b 使用顶点数组..如glDrawArrays.glDrawElements.等.一次性的绘制大量图元.


//2顶点处理操作（顶点的属性特征-》变换后的顶点数据 //Vertex Shader(顶点着色器) 替换 顶点处理阶段
//a 顶点变换：根据模型视图和投影矩阵变换
//b 光照计算和法线变换(法线矩阵 是模型矩阵的左上角3*3的逆矩阵)和法线规格化
//c 纹理坐标变换.(纹理矩阵)
//d 材质状态：纹理坐标生成
//这个阶段所接收到的数据则是每个顶点的属性特征..输出则是变换后的顶点数据

//3图元组装（顶点数据变成图元，图元包括点.线.三角形）
//在顶点处理之后,顶点的全部属性都已经被确定。在这个阶段顶点将会根据应用程序送往的图元规则如GL_POINTS 、GL_TRIANGLES 等将会被组装成图元。


//4图元处理（opengles没有这步操作）
//<1>这个步骤第一个所做的应当是裁剪操作，会将图元与用户定义的裁剪平面，即glClipPlane 和模型投影矩阵所建立的视景比较. 这将会裁剪且丢弃位于视景和裁剪平面外部的图元.不在予以处理.
//<2> 其次.若是采用透视投影 那么.将会对每个顶点的x,y z坐标分别除以w.
//<3>紧接着，则是由视口变换将顶点坐标变换至窗口坐标.
//<4> 执行消隐操作

//5栅格化操作（光栅化 3d矢量数据-》屏幕像素）
//<1>由图元处理传递过来的图元数据.在此将会被分解成更小的单元并对应帧缓冲区的各个像素.这些单元被称之为片元. 一个片元可能包含窗口左边、深度、颜色、纹理坐标等属性.
//<2> 片元的属性则是图元上顶点数据等经过插值而确定的..这里生成的片元将会包含主颜色和次颜色.   glShadeMode() 函数的作用将会这里体现.即使用插值(平滑着色) 或者使用最后一个顶点颜色(平面着色)
//<3> 点宽 线宽.多边形模式,正面背面等一些特征也将是这阶段发生作用.
//<4> 反走样也是这个阶段起作用.

//6 片元处理 （片元=片段=像素）       //(片元着色器，又叫像素着色器) 替换 片元处理阶段
//<1>上纹理：通过纹理坐标取得纹理内存中相对应的颜色。
//<2> 雾化：通过片元距离当前视点位置修改颜色.
//<3> 颜色汇总..这个与混合完全不同概念.将纹理,主定义的颜色,雾化的颜色,次颜色光照阶段计算的颜色 汇总一起.

//7 逐个片元的操作(逐个像素操作)
//<1> 所有的一些测试 像素所有权 剪切(glScissor) Alpha测试(glAlphaFunc) 模版测试(glStencilFunc) 深度测试 (glDephtFunc) 混合(glBlendFunc)

//8 帧缓冲操作（准备像素输出）
//<1>这个阶段执行帧缓冲的写入等操作等..最后产生了显示出来的像素.



//可编程管线可以替换的功能
//Vertex Shader(顶点着色器) 替换 顶点处理阶段
//Fragment Shader(片元着色器，又叫像素着色器) 替换 片元处理阶段
 

//cg语法基础
//http://blog.csdn.net/mobanchengshuang/article/details/38664541
//https://www.zhihu.com/question/21451211
//https://onevcat.com/2013/07/shader-tutorial-1/



 

//Unity每次在准备数据并通知GPU渲染的过程称为一次Draw Call。
//一般情况下，渲染一次拥有一个网格并携带一种材质的物体便会使用一次Draw Call

//顶点着色器的输出参数可以说是直接作为了片段着色器的形参传递过来，那么不由得一个问题浮现出来，顶点着色器的形参是从何处传递过来的？


// 那么顶点着色器可以根据语义获取到的全部mesh信息有：
// float4 vertex : POSITION; //顶点坐标
// float4 tangent : TANGENT; // tangent，三角函数的一种，缩写为tan我们很熟悉了，他的值是mesh到表面法线的正切值
// float3 normal : NORMAL; //表面法向量，以对象的坐标系标准化至单位长度
// float4 texcoord : TEXCOORD0;//纹理坐标系的第0个集合
// float4 texcoord1 : TEXCOORD1; //纹理坐标系的第1个集合
// fixed4 color : COLOR;//颜色，通常为常数

//同理我们可以声明一个顶点着色器的输入结构体，包含以上所有信息，然后将这个结构体作为形参传递给顶点着色器的入口函数。

// Unity内建的预定义输入结构体：
// 只要引用UnityCg.cginc头文件(目录Unity > Editor > Data > CGIncludes下)就可以使用预先设定好的结构体直接使用，他们分别有appdata_base  appdata_tan和appdata_full:

// struct appdata_base {  
// float4 vertex : POSITION;  
// float3 normal : NORMAL;  
// float4 texcoord : TEXCOORD0;  
// };  
// struct appdata_tan {  
//   
// float4 vertex : POSITION;  
// float4 tangent : TANGENT;  
// float3 normal : NORMAL;  
// float4 texcoord : TEXCOORD0;  
// };  
// struct appdata_full {  
// float4 vertex : POSITION;  
// float4 tangent : TANGENT;  
// float3 normal : NORMAL;  
// float4 texcoord : TEXCOORD0;  
// float4 texcoord1 : TEXCOORD1;  
// fixed4 color : COLOR;  
//   
// };  

//如果原信息的值域的每个分量不在[0,1] 只需要将原信息的值域变换至这个区间内，使其每个分量都不超过[0,1]这个区间，我们就能将mesh信息与颜色建立单向映射体现出来。

//output.col = input.texcoord;
//output.col = float4(input.texcoord.x, 0.0, 0.0, 1.0);
//output.col = float4((input.normal + float3(1.0, 1.0, 1.0)) / 2.0, 1.0); 
//该点的颜色 等于 该点的纹理坐标

//通过两个pass 
//一个完整的球先切前面给后面上色
//一个完整的球切后面给前面上色
//把两个pass的结果结合


//RoundShader 可能会超出边界。
//需要增加顶点着色器，   片段着色器才会正常






//顶点数据：通过语义输入顶点参数：position，color，normal，texcoord0，texcoord1
//顶点着色：输出 position，sv_position，Psize
//几何图元生成：输出顶点参数
//光栅化：通过语义产生片段输入参数
//片段着色器：输出color，depth

//uniforms是unity提供给我们的特定参数，他们也有向量、标量和矩阵，他独立于片段、顶点、图元之外而存在，如果将他们组成的网格mesh理解为一个庞大的宇宙，这些uniforms就好似大宇宙中的物理法则，对于任何的顶点、片段、图元都适用，且数值相同。

//顶点变换：
//对象/模型坐标系-世界坐标系-观察者坐标系-裁剪坐标系-普通设备坐标系-屏幕/窗口坐标系
//object-world    world-view  projection  透视变换    视窗变换

//需要注意的是，前3个变换是在顶点着色器中完成的，而透视变换域视窗变换是在后续的环节中完成的。也就是说只有前3个变换过程是可编程的。
//前3个变换所用到的3个矩阵均可以通过uniform参数获取，并且unity还提供了一个MVP参数，即整合了这3个矩阵，直接完成从模型坐标系至裁剪坐标系的变换。


//单位矩阵
//单位矩阵的特性：任何矩阵乘以单位矩阵，还是得到原矩阵

//平移
//任何平移过程都是变换矩阵乘以Mt矩阵的过程

//旋转
//旋转比较复杂，任意旋转向量R=(Rx,Ry,Rz)分别表示绕x,y,z轴旋转的弧度数，将这个1X3矩阵等价的变换为4x4矩阵

//缩放
//任何缩放过程都是变换矩阵乘以Ms矩阵的过程  特殊的就好比 任何矩阵乘以Sx~Sz都为1的矩阵Ms,图形不发生变换

//复合矩阵
//前面提到的 位于顶点着色器管辖范围内的3个4X4变换矩阵MobjectToWorld(modelToWorld),简写Mm,MworldToView,简写Mv,Mprojection,简写Mp
//顶点着色器将输入参数中的顶点坐标按照这3个矩阵进行连续变换即得到剪裁坐标系中的矩

//M原始矩阵*Mm*Mv*Mp=M剪裁坐标系中的矩阵

//那么任意对象/模型坐标系中的原始矩阵M 与Mcombine相乘可以得到剪裁坐标系中的矩阵，因此Unity提供的MVP参数正是这样一个复合矩阵

// uniform float4x4 UNITY_MATRIX_MVP; // model view projection 矩阵  
// uniform float4x4 UNITY_MATRIX_MV; // model view 矩阵  
// uniform float4x4 UNITY_MATRIX_P; // projection 矩阵  
// uniform float4x4 UNITY_MATRIX_T_MV;  
// //  model view 矩阵的转置(transpose)矩阵  
// uniform float4x4 UNITY_MATRIX_IT_MV;  
// // model view 矩阵的逆矩阵的转置矩阵  
// uniform float4x4 UNITY_MATRIX_TEXTURE0; // 纹理矩阵  
// uniform float4x4 UNITY_MATRIX_TEXTURE1; // 纹理矩阵  
// uniform float4x4 UNITY_MATRIX_TEXTURE2; // 纹理矩阵  
// uniform float4x4 UNITY_MATRIX_TEXTURE3; // 纹理矩阵  
// uniform float4 UNITY_LIGHTMODEL_AMBIENT; // 环境颜色  


// 不透明度
// 当我们要将两个半透的纹理贴图到一个材质球上的时候就遇到混合的问题，由于前面的知识我们已经知道了片段着色器以及后面的环节的主要工作是输出颜色与深度到帧缓存中，所以两个纹理在每个像素上的颜色到底以怎样的形式混合在一起最后输出到帧缓存中是我们现在首要讨论的内容。

//混合(blending)
//上一篇文章中的管道环节中的“逐帧操作”环节中的一项操作就是混合操作，可见混合操作是不可编程的固定功能环节

//在混合操作中，我们将片段着色器中计算出来的颜色称之为 “源颜色”，帧缓存中对应的像素已经存在的颜色叫做“目标颜色”。混合操作就是将源颜色与目标颜色以一些选项进行结合。

// 我们选择混合的选项的过程是通过以下面的等式来进行RGBA颜色的计算的:
// float4 result = SrcFactor * fragment_output + DstFactor * pixel_colo

//其中 fragment_output 是通过片段着色器计算的 RGBA 颜色，pixel_color 是当前帧缓冲区的颜色，result 是混合结果（混合输出阶段），SrcFactor 和 DstFactor 是可配置的 RGBA 颜色（类型是 float4），并且片段颜色和帧颜色的各个分量分别相乘，SrcFactor 和 DstFactor 的值在 Unity ShaderLab 中可以用下面语法指定 ：
//Blend {code for SrcFactor} {code for DstFactor}



//混合产生的结果 =  片段着色器计算出来RGBA颜色，源颜色混合选项
//               +  帧缓存中已存在的对应像素的RGBA颜色，目标颜色混合选项



//Unity中的Shader 通过ShaderLab语法表达的混合操作过程为：
//Blend  SrcFactor  DstFactor 

// 
// 其中这2个代号分别可以选择的选项如下表：
// 选项代号
// 与之等价的代码
// One// float4(1.0)
// Zero// float4(0.0)
// SrcColor// fragment_output
// SrcAlpha// float4(fragment_output.a)
// DstColor// pixel_color
// DstAlpha// float4(pixel_color.a)
// OneMinusSrcColor// float4(1.0) - fragment_output
// OneMinusSrcAlpha// float4(1.0 - fragment_output.a)
// OneMinusDstColor// float4(1.0) - pixel_color
// OneMinusDstAlpha// float4(1.0 - pixel_color.a)
// 其中float4(1.0)的写法我们前面已经见过，等价于float4(1.0,1.0,1.0,1.0)
// 并且其中所有向量的分量区间都是[0,1]区间。


//Blend One OneMinusSrcAlpha
//float4 result = float4(1.0, 1.0, 1.0, 1.0) * fragment_output + (float4(1.0, 1.0, 1.0, 1.0) - fragment_output.aaaa) * pixel_color;


//Blend One One
//float4 result = float4(1.0, 1.0, 1.0, 1.0) * fragment_output + float4(1.0, 1.0, 1.0, 1.0) * pixel_color;









//用shaderlab来组织shader结构，cg,hlsl实际shader代码镶嵌在shaderlab里面


