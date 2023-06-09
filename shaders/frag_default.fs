#version 330 core
out vec4 FragColor;

uniform float iTime;

in vec3 ourColor;
in vec2 fragCoord;

// texture sampler

vec3 palette( float t ) {
    // vec3 a = vec3(0.5, 0.5, 0.5);
    // vec3 b = vec3(0.5, 0.5, 0.5);
    // vec3 c = vec3(1.0, 1.0, 1.0);
    // vec3 d = vec3(0.263,0.416,0.557);
	vec3 a = vec3(0.463, 0.193, 0.392);
    vec3 b = vec3(0.796, 0.927, 0.754);
    vec3 c = vec3(1.337, 1.538, 0.336);
    vec3 d = vec3(3.894,5.989,3.587);

    return a + b*cos( 6.28318*(c*t+d) );
}

void main()
{
	vec2 uv = fragCoord;
	uv = uv * 2.0 - 1;

	float L = length(uv);
	vec3 finalColor = vec3(0.0f, 0.0f, 0.0f);
	float d;

	for (float i = 0.0; i < 4.0; i++) {
		uv = fract(uv * 1.8) - 0.5;

		d = length(uv) * exp(-L);
		vec3 col = palette(L + (i + iTime) * 0.4f);

		d = sin(d * 8.0 + iTime) / 8.0f;
		d = abs(d);
		d = pow(0.01 / d, 1.2);
		finalColor += col * d;
	}

	FragColor = vec4(finalColor, 1.0f);
}