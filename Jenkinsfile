def REMOTE = [
    name: 'rankin',
    host: 'rankin.quidgest.pt',
    user: 'marcos.alameda@quidgest.pt',
    credentialsId: 'linux-docker-ssh',
    allowAnyHosts: true
]

pipeline {
    agent any

    options {
        timestamps()
    }

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Run Selenium + ZAP on Linux') {
            steps {
                script {
                    def output = sshCommand(
                        remote: REMOTE,
                        returnStdout: true,
                        command: '''
                            cd /home/marcos.alameda@quidgest.pt/OWASPselenium
                            docker-compose down || true
                            docker-compose up --build --abort-on-container-exit

                            if [ -f zap-reports/zap-report.html ]; then
                                echo "===ZAP_REPORT_START==="
                                base64 zap-reports/zap-report.html
                                echo "===ZAP_REPORT_END==="
                            fi
                        '''
                    )

                    if (output?.contains('===ZAP_REPORT_START===')) {
                        def encoded = output
                            .split('===ZAP_REPORT_START===')[1]
                            .split('===ZAP_REPORT_END===')[0]
                            .trim()

                        writeFile(
                            file: 'zap-reports/zap-report.html',
                            text: new String(encoded.decodeBase64())
                        )
                    }
                }
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: 'zap-reports/*.html',
                             allowEmptyArchive: true,
                             fingerprint: true
        }
        success {
            echo 'Pipeline executed successfully'
        }
        failure {
            echo 'Pipeline failed'
        }
    }
}
