pipeline {
    agent {
        label 'windowsAgent1'
    }
    stages {
        stage('Static Analysis') {
            steps {
                bat 'SonarScanner.MSBuild.exe begin /k:"org.sonarqube:sonarqube-scanner-msbuild" /n:"Jenkins MSBuild project" /v:"1.0"'
                bat 'MSBuild.exe /t:Rebuild'
                bat 'SonarScanner.MSBuild.exe end'
            }
        }
        stage("Build") {
             steps {
                bat "msbuild ./JenkinsMSBuildExample.csproj"
            }
        }
    }
}