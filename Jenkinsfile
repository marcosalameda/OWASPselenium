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
                // ✅ Inyectar CSS personalizado en el HTML de ZAP para mejor legibilidad
                sh '''
                  python3 ci/enhance-zap-report.py \
                    zap-reports/zap-report.html \
                    zap-reports/zap-report-enhanced.html || true
                '''
            }
        }
    }
    post {
        always {
            // ✅ Publicar como HTML interactivo navegable en la UI de Jenkins
            publishHTML(target: [
                allowMissing         : true,
                alwaysLinkToLastBuild: true,
                keepAll              : true,
                reportDir            : 'zap-reports',
                reportFiles          : 'zap-report-enhanced.html',
                reportName           : 'OWASP ZAP Security Report',
                reportTitles         : 'ZAP Report'
            ])

            // ✅ Archivar también el HTML original como respaldo
            archiveArtifacts artifacts: 'zap-reports/**/*', allowEmptyArchive: true

            sh 'docker compose down -v --remove-orphans || true'
        }
        failure {
            echo '⚠️ El pipeline ha fallado. Revisa el Console Log y el informe ZAP.'
        }
        success {
            echo '✅ Tests y análisis de seguridad completados correctamente.'
        }
    }
}
