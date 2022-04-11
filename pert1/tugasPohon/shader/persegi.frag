#version 330

out vec4 outputColor;

in vec4 vertexColor;
//
//uniform vec4 ourColor;

void main()
{
	//outputColor = ourColor;
	//outputColor = vertexColor;
	outputColor = vec4(0.54,0.27,0.08,1.0);
}