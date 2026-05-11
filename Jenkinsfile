pipeline {
    agent { label 'docker' }

    environment {
        COMPOSE_PROJECT_NAME = "owasp-selenium-${env.BUILD_NUMBER}"
        ZAP_CONTAINER_NAME   = "zap-${env.BUILD_NUMBER}"
        SELENIUM_HUB_NAME    = "selenium-hub-${env.BUILD_NUMBER}"
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
                  docker compose down -v --remove-orphans || true
                  docker compose up --build --abort-on-container-exit
                '''
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: 'zap-reports/**/*', allowEmptyArchive: true
            sh 'docker compose down -v --remove-orphans || true'
        }
    }
}
``
