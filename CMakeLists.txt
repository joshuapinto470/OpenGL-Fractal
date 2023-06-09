cmake_minimum_required(VERSION 3.10)
project(OpenGL_Fractal)
set (CMAKE_CXX_STANDARD 17)


include_directories(
        "libs/glfw/include"
        "libs/glad/include/"
        "includes/"
	"includes/glm/"
)


SET(GLFW_BUILD_DOCS OFF CACHE BOOL "" FORCE)
SET(GLFW_BUILD_TESTS OFF CACHE BOOL "" FORCE)
SET(GLFW_BUILD_EXAMPLES OFF CACHE BOOL "" FORCE)
add_subdirectory(libs/glfw/)

SET(SRC_FILES 
"libs/glad/src/glad.c"
"src/main.cpp"
"src/shader.cpp"
)

add_executable(Fractal
${SRC_FILES}
)


if(WIN32)
        target_link_libraries(Fractal PRIVATE glfw opengl32)
endif(WIN32)

if(UNIX)
        target_link_libraries(Fractal PRIVATE glfw GL)
endif(UNIX)
