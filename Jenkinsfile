pipeline {
    agent any

    environment {
        DOCKER_BUILDKIT = '1'
        COMPOSE_DOCKER_CLI_BUILD = '1'
    }

    options {
        timestamps()
    }

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Run Selenium + ZAP') {
            steps {
                sh '''
                    set -e
                    echo "▶️ Starting Selenium + ZAP stack"

                    docker compose down || true
                    docker compose up --build --abort-on-container-exit
                '''
            }
        }
    }

    post {
        always {
            echo "🧹 Cleaning Docker resources"
            sh 'docker compose down || true'
            archiveArtifacts artifacts: 'zap-reports/*.html', fingerprint: true
        }
        success {
            echo '✅ Selenium + ZAP executed successfully'
        }
        failure {
            echo '❌ Selenium tests failed'
        }
    }
}
