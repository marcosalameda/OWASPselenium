pipeline {
    agent { label 'linux-docker' }

    stages {
        stage('Run Selenium + ZAP') {
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
            archiveArtifacts 'zap-reports/zap-report.html'
            sh 'docker compose down -v || true'
        }
    }
}
