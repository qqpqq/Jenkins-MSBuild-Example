pipeline {
    agent {
        label 'windowsAgent1'
    }
    stages {
        stage('Static Analysis') {
            steps {
                sh 'SonarScanner.MSBuild.exe begin /k:"org.sonarqube:sonarqube-scanner-msbuild" /n:"Jenkins MSBuild project" /v:"1.0"'
                sh 'MSBuild.exe /t:Rebuild'
                sh 'SonarScanner.MSBuild.exe end'
            }
        }
        stage("Build") {
             steps {
                bat "msbuild ./JenkinsMSBuildExample.csproj"
            }
        }
    }
}