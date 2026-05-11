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

    post {
        always {
            echo 'Fetching ZAP report from Linux'

            sshGet(
                remote: REMOTE,
                from: '/home/marcos.alameda@quidgest.pt/OWASPselenium/zap-reports/*.html',
                into: 'zap-reports/',
                override: true
            )

            archiveArtifacts artifacts: 'zap-reports/*.html',
                             allowEmptyArchive: true,
                             fingerprint: true
        }

        success {
            echo 'Pipeline executed successfully'
        }

        failure {
            echo 'Pipeline failed'
        }
    }
}
