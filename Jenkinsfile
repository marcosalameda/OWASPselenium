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
                sshCommand(
                    remote: REMOTE,
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
        success {
            echo '✅ Selenium + ZAP executed successfully on Linux'
            echo 'ℹ ZAP report available on Linux host'
            echo 'ℹ Path: /home/marcos.alameda@quidgest.pt/OWASPselenium/zap-reports/zap-report.html'
        }

        failure {
            echo '❌ Pipeline failed'
        }
    }
}
