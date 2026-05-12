pipeline {
    agent { label 'docker' }
    environment {
        COMPOSE_PROJECT_NAME = "owasp-selenium-${env.BUILD_NUMBER}"
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
        stage('Procesar informe ZAP') {
            steps {
                script {
                    if (fileExists('zap-reports/zap-report.html')) {
                        echo "✅ Informe ZAP generado correctamente."
                        echo "📥 Descargable en: ${env.BUILD_URL}artifact/zap-reports/zap-report.html"
                    } else {
                        echo "⚠️ No se encontró el informe ZAP."
                    }
                }
            }
        }
    }
    post {
    always {
        archiveArtifacts artifacts: 'zap-reports/**/*', allowEmptyArchive: true
        sh '''
          export ZAP_PROXY=http://zap:8080
          export SELENIUM_REMOTE_URL=http://selenium-hub:4444/wd/hub
          docker compose down -v --remove-orphans || true
        '''
        failure {
            echo '⚠️ Pipeline fallido. Revisa el Console Log y el informe ZAP.'
        }
        success {
            echo '✅ Tests y análisis de seguridad completados correctamente.'
        }
    }
}
