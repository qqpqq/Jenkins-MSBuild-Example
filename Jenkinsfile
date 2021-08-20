pipeline {
    agent {
        label 'windowsAgent1'
    }
    stages {
        stage('Install Dependencies') {
            steps {
                bat 'nuget restore'
            }
        }
        stage('Static Analysis') {
            steps {
                bat 'SonarScanner.MSBuild.exe begin /k:"org.sonarqube:sonarqube-scanner-msbuild" /n:"Jenkins MSBuild project" /v:"1.0"'
                bat 'MSBuild.exe /t:Rebuild'
                bat 'SonarScanner.MSBuild.exe end'
            }
        }
        stage('OpenCover') {
            steps {
                bat 'choco install opencover -y'
                bat 'mkdir opencover'
                bat 'OpenCover.Console.exe -register:user -target:"vstest.console.exe" -targetargs:"./JenkinsMSBuildExampleTest/bin/Debug/JenkinsMSBuildExampleTest.dll" -output:"./opencover/result.xml"'
                publishCoverage adapters: [opencoverAdapter(mergeToOneReport: true, path: '**/opencover/*.xml')], sourceFileResolver: sourceFiles('NEVER_STORE')
            }
        }


        stage("Build") {
             steps {
                bat "msbuild"
            }
        }
    }
}