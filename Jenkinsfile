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
                sshagent(credentials: ['linux-docker-ssh']) {
                    bat '''
                        echo Running Docker Compose on Linux

                        ssh -o StrictHostKeyChecking=no marcos.alameda@rankin.quidgest.pt ^
                          "cd /home/marcos.alameda/OWASPselenium && \
                           docker-compose down || true && \
                           docker-compose up --build --abort-on-container-exit"
                    '''
                }
            }
        }
    }

    post {
        always {
            echo 'Fetching ZAP report'
            sshagent(credentials: ['linux-docker-ssh']) {
                bat '''
                    if not exist zap-reports mkdir zap-reports
                    scp -o StrictHostKeyChecking=no marcos.alameda@rankin.quidgest.pt:/home/marcos.alameda/OWASPselenium/zap-reports/*.html zap-reports/ || exit 0
                '''
            }
            archiveArtifacts artifacts: 'zap-reports/*.html', allowEmptyArchive: true
        }
    }
}
