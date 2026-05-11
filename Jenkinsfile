def REMOTE = [
    name: 'rankin',
    host: 'rankin.quidgest.pt',
    user: 'marcos.alameda@quidgest.pt',
    credentialsId: 'linux-docker-ssh',
    allowAnyHosts: true
]

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

        stage('Run Selenium + ZAP on Linux') {
            steps {
                catchError(buildResult: 'SUCCESS', stageResult: 'SUCCESS') {
                    sshCommand(
                        remote: REMOTE,
                        command: '''
                            cd /home/marcos.alameda@quidgest.pt/OWASPselenium
                            docker-compose down || true
                            docker-compose up --build --abort-on-container-exit
                        '''
                    )
                }
            }
        }
    }

    post {
        always {
            echo 'Ejecución remota lanzada.'
            echo 'Resultados y reportes se encuentran en el host Linux:'
            echo '/home/marcos.alameda@quidgest.pt/OWASPselenium/zap-reports/'
        }
    }
}
