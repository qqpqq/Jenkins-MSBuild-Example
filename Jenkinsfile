pipeline {
    agent {
        label 'windowsAgent1'
    }
    stages {
        stage("Build") {
             steps {
                bat "msbuild ./JenkinsMSBuildExample.csproj"
            }
        }
    }
}