#version 330 core
layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec2 aTexCoord;

out vec2 texCoord;

uniform mat4 transform;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform mat4 MovingMatrix;

void main()
{
    	gl_Position = vec4(aPosition, 1.0) * model * view*   projection;
	texCoord = vec2(aTexCoord.x, aTexCoord.y);
	
}