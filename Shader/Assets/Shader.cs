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
//1 基于direct3d的hlsl
//2 基于opengl的glsl
//3 基于nvidia的cg，cg与hlsl相似，cg同时兼容direct3d和opengl
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



//用shaderlab来组织shader结构，cg,hlsl实际shader代码镶嵌在shaderlab里面


