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
                sshCommand(
                    credentialsId: 'linux-docker-ssh',
                    host: 'rankin.quidgest.pt',
                    user: 'marcos.alameda@quidgest.pt',
                    command: '''
                        cd /home/marcos.alameda@quidgest.pt/OWASPselenium
                        docker-compose down || true
                        docker-compose up --build --abort-on-container-exit
                    '''
                )
            }
        }
    }

    post {
        always {
            echo 'Fetching ZAP report from Linux'
            sshGet(
                credentialsId: 'linux-docker-ssh',
                remote: '/home/marcos.alameda@quidgest.pt/OWASPselenium/zap-reports/*.html',
                local: 'zap-reports/',
                failOnError: false
            )

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
