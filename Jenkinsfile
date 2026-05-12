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
                    } else {
                        echo "⚠️ No se encontró el informe ZAP."
                    }
                }
            }
        }
    }

    post {
        always {
            // Archivamos los resultados antes de limpiar
            archiveArtifacts artifacts: 'zap-reports/**/*', allowEmptyArchive: true
            
            // Limpieza de contenedores
            sh 'docker compose down -v --remove-orphans || true'
        }
        
        failure {
            echo '⚠️ Pipeline fallido. Revisa el Console Log y el informe ZAP.'
        }
        
        success {
            echo '✅ Tests y análisis de seguridad completados correctamente.'
        }
    }
} // <--- Esta es la llave que probablemente faltaba
