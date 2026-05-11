pipeline {
    agent { label 'docker' }

    environment {
        COMPOSE_PROJECT_NAME = 'owasp-selenium'
    }

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
            archiveArtifacts artifacts: 'zap-reports/**/*', allowEmptyArchive: true
            sh 'docker compose down -v || true'
        }
    }
}
