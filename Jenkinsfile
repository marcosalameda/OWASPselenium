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

        stage('Run Selenium + ZAP') {
            steps {
                bat '''
                    echo ▶ Starting Selenium + ZAP stack

                    docker-compose down || exit 0
                    docker-compose up --build --abort-on-container-exit
                '''
            }
        }
    }

    post {
        always {
            echo 🧹 Cleaning Docker resources
            bat 'docker-compose down || exit 0'

            echo 📦 Archiving ZAP report (if present)
            archiveArtifacts artifacts: 'zap-reports/*.html', allowEmptyArchive: true, fingerprint: true
        }
        success {
            echo ✅ Selenium + ZAP executed successfully
        }
        failure {
            echo ❌ Selenium tests failed
        }
    }
}
