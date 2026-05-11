pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Run Selenium + OWASP ZAP') {
            steps {
                sh '''
                  docker compose down -v || true
                  docker compose up --build --abort-on-container-exit
                '''
            }
        }
    }

    post {
        always {
            echo 'Archiving OWASP ZAP security report'

            archiveArtifacts artifacts: 'zap-reports/zap-report.html', allowEmptyArchive: true

            sh 'docker compose down -v || true'
        }
    }
}
