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

        stage('OpenCover') {
            steps {
                bat 'choco install opencover -y'
                bat 'OpenCover.Console.exe -register:user -target:"vstest.console.exe" -targetargs:"./JenkinsMSBuildExampleTest/bin/Debug/JenkinsMSBuildExampleTest.dll /ResultsDirectory:./TestResults/testResults.trx" -output:"./result.xml"'
                publishCoverage adapters: [opencoverAdapter(mergeToOneReport: true, path: 'result.xml')], sourceFileResolver: sourceFiles('NEVER_STORE')
            }
        }

        stage('Static Analysis') {
            steps {
                withSonarQubeEnv('SonarQube-Server') {
                    bat 'SonarScanner.MSBuild.exe begin /k:"org.sonarqube:sonarqube-scanner-msbuild" /n:"Jenkins MSBuild project" /v:"1.0"'
                    bat 'MSBuild.exe /t:Rebuild'
                    bat 'SonarScanner.MSBuild.exe end'
                }
            }
        }

        stage("Build") {
             steps {
                bat "msbuild"
            }
        }
    }
}