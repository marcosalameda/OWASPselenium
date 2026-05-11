post {
    always {
        echo 'Fetching ZAP report from Linux via SSH'

        sshCommand(
            remote: REMOTE,
            command: '''
                if [ -f /home/marcos.alameda@quidgest.pt/OWASPselenium/zap-reports/zap-report.html ]; then
                    base64 /home/marcos.alameda@quidgest.pt/OWASPselenium/zap-reports/zap-report.html
                fi
            '''
        ).with { output ->
            if (output?.trim()) {
                writeFile(
                    file: 'zap-reports/zap-report.html',
                    text: new String(output.trim().decodeBase64())
                )
            }
        }

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
