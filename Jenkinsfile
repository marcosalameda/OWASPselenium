pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build & Run Selenium + OWASP ZAP (via Docker Compose container)') {
            steps {
                bat '''
                  REM Stop anything left from previous runs
                  docker run --rm ^
                    -v "%CD%":/work ^
                    -w /work ^
                    docker/compose:1.29.2 down -v || exit 0

                  REM Build images
                  docker run --rm ^
                    -v "%CD%":/work ^
                    -w /work ^
                    docker/compose:1.29.2 build

                  REM Run stack (Selenium exits → whole stack exits)
                  docker run --rm ^
                    -v "%CD%":/work ^
                    -w /work ^
                    docker/compose:1.29.2 up --abort-on-container-exit
                '''
            }
        }
    }

    post {
        always {
            echo 'Archiving OWASP ZAP security report'

            archiveArtifacts artifacts: 'zap-reports/zap-report.html', allowEmptyArchive: true

            bat '''
              docker run --rm ^
                -v "%CD%":/work ^
                -w /work ^
                docker/compose:1.29.2 down -v || exit 0
            '''
        }
    }
}
