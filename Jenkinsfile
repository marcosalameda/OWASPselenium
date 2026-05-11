pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build containers') {
            steps {
                bat '''
                  docker-compose down -v || exit 0
                  docker-compose build
                '''
            }
        }

        stage('Run Selenium + OWASP ZAP') {
            steps {
                bat '''
                  docker-compose up --abort-on-container-exit
                '''
            }
        }
    }

    post {
        always {
            echo 'Archiving OWASP ZAP security report'
            archiveArtifacts artifacts: 'zap-reports/zap-report.html', allowEmptyArchive: true

            bat 'docker-compose down -v || exit 0'
        }
    }
}
