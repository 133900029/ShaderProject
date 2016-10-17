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
//unity 书本



 

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


//
//那么镜面反射与漫反射的区别就是光碰到的物体表面被弹回来的过程中，表面的平整程度，越平越接近镜面反射，越粗糙就是漫反射。我们现实生活中看到的绝大部分东西的表面都是粗糙的，所以都是漫反射。
//在讨论漫反射之前一定要回过头来复习一下我们的物理科学中的镜面反射与折射，因为漫反射可以拆分为无数个微小的镜面反射(就像圆形可以看做无数条边的正多边形)，毕竟游戏世界也是为了模拟物理世界，游戏引擎必须要符合物理规律

//好了 接下来我们将前文提到的入射光线、法线 替换为入射向量L(表面到光源的方向为正方向)、法向量N。

// 那么我们的物体表面发生漫反射时，漫反射的量即是由入射向量I与每一个顶点位置的法向量N确定的：
// diffuse=L·N
// 这个过程是向量I与N进行点乘，其过程为:
// diffuse=|L|*|N|*cos∠(L,N)

// 由于我们直接讨论入射向量与法向量的单位向量，所以两个绝对值为1，那么漫反射duffuse=cos∠(L,N)
// 由此我们可以得到单位向量的入射光的漫反射强度diffuse的值域为:[-1,1]
// 由余弦曲线可以得知，diffuse在夹角为0~90°为正，90°~270°为负，270~360°为正 
// 对于cos∠(L,N)超过90°的情况，我们认为入射光已经在介质表面的另外一面了，这种情况我们不考虑，一般来说漫反射都是在外表面进行的。
// 所以我们的diffuse当夹角超过90°时便认为反射量为0，所以我们对该式子修改为:
// diffuse=max(0,cos∠(L,N))
// 即对入射向量与法向量的夹角的余弦 与0 取最大值，保证了反射量不会出现负数。

// 1.光源的位置由unity的内置uniform参数 _WorldSpaceLightPos0给出，由此我们可以计算出每个顶点的入射向量
// 2.光源的颜色由uniform参数_LightColor0给出
// 3.法向量直接通过顶点着色器的输入参数中的带语义NORMAL来获得
// 有了入射向量、法向量、光源颜色，我们就能在顶点着色器中计算出每个顶点位置的反射量，并与光源颜色和材料颜色相乘得到最终表面实际着色的颜

//true
//float4 y
//float3 x = y
//
//error
//float3 x = float3(x)



// 前文中完成最简单的漫反射shader只是单个光源下的漫反射，而往往场景中不仅仅只有一个光源，那么多个光源的情况下我们的物体表面的漫反射强度如何叠加在一起呢？前文打的tag "LightMode"="ForwardBase"又是什么意思呢？
// Unity内置的DiffuseShader，也就是我们创建一个Material出来时默认的Shader也是多光源的，所以这篇文章完成的shader与默认的diffuse shader基本效果一致。

// Unity在处理多光源的情况时为我们提供了三种模式:修改的地方在 Edit--Project Settings--Player--Other Settings--Rendering Path
// 1.顶点光 Vertex Lit
// 2.方向性 Forward (默认)
// 3.延迟照明 Deferred Lighting 
// 我们的shader也使用默认的Forward



// Unity中将平行光称作为像素光，第一个像素光是基础平行光，以LightMode=ForwardBase标签修饰，每多一个像素光都以LightMode=ForwardAdd标签修饰。
// 并不是所有的光源在运行时都会反射到物体上，而是根据Project的Quality中设置的像素光数量来渲染的。
// 
// 默认像素光的数量应该是2，我们有更多的平行光照在物体上，就需要在Edit > Project Settings > Quality中去调节像素光的数量Pixel Light Count

//讲两个pass的输出进行混合
// 前面的系列6中已经讲过片段着色器是要将mesh组件传递的信息最终计算为颜色(或者深度)存储在帧缓存(Frame Buffer)中。
// 每个Pass之间输出的颜色通过一定的公式进行混合。
// 
// 在这里我们简单实用一比一的模式进行颜色混合,即混合指令为:
//blend one one

// (1)Vertex Lit Rendering path （定义了Vertex,VertexLMRGBM以及VertexLM 3种Pass）
// (2)Forward Rendering path（定义了ForwordBase和FowordAdd 2种Passes）
// (3)Deferred Rendering path（定义了PrepareBase和PrepareFinal 2种Passes）


// 平行光（directional light）
// 一种是从特定方向射入并只会照亮面对入射方向的物体，我们称之为平行光（directional light）。
// 环境光（ambient light）
// 另一种光是来自所有方向并且会照亮所有物体，不管这些物体的朝向如何，我们称之为环境光（ambient light）。当然在真实世界里，这只是平行光照到其他物体上，比如空气、灰尘等等，然后反射出来的散射而已。但是在这里，我们需要把它单独作为一个光照模型列出来。
// 漫反射（Diffuse）
// 无论光的入射角度如何，都会向所有方向发生反射。反射光的亮度只和光线的入射角度有关，与观察角度无关。光线越平行于物体表面，则反射光越弱，表面越暗；光线越垂直于表面，反射光越强，表面越亮。漫反射是我们通常想到一个物体受到光照时需要首先想到的。
// 镜面反射（Specular）
// 这就像镜子一样，反射光将按照和入射角相同的角度反射出来。这种情况下，你看到的物体反射出来的光的亮度，取决于你的眼睛和光反射的方向是否在同一直线上；也就是说，反射光的亮度不仅与光线的入射角有关，还与你的视线和物体表面之间的角度有关。镜面反射通常会造成物体表面上的“闪烁”和“高光”现象，镜面反射的强度也与物体的材质有关，无光泽的木材很少会有镜面反射发生，而高光泽的金属则会有大量镜面反射。

// 冯氏反射模型(Phong Rlection Model)
// 冯氏反射模型引申了这个四步走的光照系统，首先所有的光线都有以下两个属性：
// 
//     发生漫反射光的RBG值。
//     发生镜面反射光的RGB值。
// 
// 其次所有材质都有以下四个属性
// 
//     反射的环境光RGB值
//     反射的漫反射光RGB值
//     反射的镜面反射光RGB值
//     物体的反光度，它决定了镜面反射的细节
// 
// 每条光线我们都需要知道两个属性，每个物体表面上的点都需要4个属性


// 我已经说明了材料表面的平整程度决定了镜面反射的明显与否，现实生活中找不到绝对平的物体表面，所以我们引入一个概念，每一种材料的表面的平整程度为Nshininess, n越大越平整，越小越粗糙，理想状态下n无穷大的时候是绝对的镜面反射，也就是前面引用的文字中所说的你想看到光源，则必须从光线的反射角完全重合去看。
// 当材料表面的粗糙程度更大时，即使我们在R附近，也能看到部分光源。
// 现实世界中的材料往往是这样的，也就是从R附近的观察这个物体时，都能看到光源的影像，至于这个附近的范围有多大，取决于材料的平整程度。



// 反射向量R与法向量N和入射向量L的数学关系为:
// R=2N(N·L)-L    (ps:N与L是点乘关系)

// 前面废话了一大堆，这里终于可以说出我想说的了:
// 观察向量V越接近R,则镜面反射越明显；
// 观察向量V越远离R,镜面反射越不明显；
// 原因就在于世界上没有绝对平整的材料。
// 所以我们终于以数学公式给出冯氏反射模型
//I(specular) = I(income)*K(specular)*max(0,R*V)光滑程度大小的次方

// 其中I specular即为镜面反射的强度，I incoming为入射光线的颜色向量 k specular为材料的镜面反射光颜色，通常是白色的
// 
// 至于max(0,R·V)又于系列中的漫反射同理，当R与V的夹角超过90°的时候余弦值为负数，物理意义为观察者从物体的内表面去看外表面了，所以我们还是与0取最大值再去做n次方
// 可见这个数学公式中镜面反射的强度与反射向量和观察向量的夹角呈指数



//环境光 float3 ambientLighting = float3(UNITY_LIGHTMODEL_AMBIENT) * float3(_Color);  
//漫反射光  float3 diffuseReflection=float3(_LightColor0) * float3(_Color)* max(0.0, dot(normalDirection, lightDirection));   
//冯氏镜面反射公式 float3 specularReflection=float3(_LightColor0)*float3(_SpecColor)*pow(max(0.0,dot(reflect(-lightDirection, normalDirection),viewDirection)),_Shininess);
//冯氏反射模型是为使计算机模拟接近真实的物体表面光泽提出的模型，即环境光(虚拟的)+漫反射光+镜面反射光=表面色彩
//单平行光源下的逐顶点着色(per-vertex lighting)，又称为古罗着色(Gouraud shading)

//======分界线

//逐像素着色(per-pixcel lighting)，又称为冯氏着色(Phong shading)


// 逐顶点着色，故名思意跟顶点有关，也就是在我们的顶点着色器中根据每个顶点上的入射向量L、法向量N、观察向量V等直接计算出每个顶点该有的颜色，然后传递给后续环节进行着色，可想而知由于顶点是离散的，片段是连续的，所以引起着色效果的不光滑很容易理解。
// 那么逐像素着色与之对应的即是在片段着色器中，对法向量与坐标进行插值(如果不能理解插值，请百度一下)，从而使离散的顶点计算出来的离散的颜色变得连续而光滑。这就是冯氏着色的要义。






//=========================================================================================================================================================================



//向量与标量乘法：a=(1,1,1) b=2  ab=(1*2,1*2,1*2)  //长度变长
//向量的加法：a=(1,1,1) b=(1,2,3) a+b=(1+1,1+2,1+3)  //平行四边形对角线
//向量的减法：a=(3,2,1) b=(1,1,1) a-b=(3-1,2-1,1-1)  //a+（-b）  和加法类似
//向量的点乘：a=(3,2,1) b=(1,2,3) ab=3*1+2*2+1*3   //投影
//向量的差乘：a=(x,y,z) b=(l,m,n) ab=(yn-zm)-(xn-zl)+(xm,yl) //长度为absin  方向为垂直ab


//矩阵的乘法
//3*2   要和 2*5 矩阵配对 然后变成 3*5
//矩阵的横 与矩阵 的竖 元素 进行点乘 得到第一个数
//一般使用横向量
//directx 用行向量
//opengl 用列向量

// 1   1      0     0
//-3 = 0  +  -3  +  0
// 4   0      0     4
           
//    xp  +  yq  + zr
//    pqr为单位变量

//v为变量p q r 的线性变换

//               px   py   pz
//  [1 -3  4] [  qx   qy   qz ]
//               rx   ry   rz
//   am=b  理解为 m将a 变换为 b
//   乘法等价与转换

// [1 0] M =[m11 m12]
//点在x为1的时候经过m转换之后变m11 m12 可以理解为m11 和m12 为转换后的基量

//  1  0  0
//  0  1  0
//  0  0  1
//可以看作对原来的坐标轴不做修改
//
//




//用shaderlab来组织shader结构，cg,hlsl实际shader代码镶嵌在shaderlab里面


