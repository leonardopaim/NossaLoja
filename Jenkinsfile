pipeline {
    agent any

    // triggers {
    //     // Executa somente de segunda a sexta às 20h, e só se houver mudanças na branch master
    //     pollSCM('15 17 * * 1-5')
    // }
    stages {
        stage('Restaurando dependencias') {
			steps {
				echo 'Enviar mensagem Jenkins'
			}
		}
    }
    post {
        success {
            script {
                def mensagem = '''
```yaml
Mensagem de descrição do último versionamento que aconteceu e como está a situação dessa descrição. Utilizando mais de uma linha para veririficar a apresentação do texto da mensagem.
```
                '''
 
                def verde = rgbToDecimalColor(25, 167, 25)
                def vermelho = rgbToDecimalColor(172, 25, 23)
                def azul = rgbToDecimalColor(66, 133, 244)
                
                notificarDiscord(
                    "Versão 1.0.0.998",
                    "Iniciando publicação... \n\n**Alterações:** ${mensagem}",
                    azul
                )
            }
        }
        failure {
            echo "falhou"
        }
    }
}

def notificarDiscord(String titulo, String descricao, int cor) {
    
    def color = cor

    def timestamp = new Date().format("yyyy-MM-dd'T'HH:mm:ssXXX")

    def payload = [
        username   : "Sofia",
        avatar_url: "https://app.sommusgestor.com/App/Images/sofia.png",
        embeds    : [[
            title      : titulo,
            url        : "${env.BUILD_URL}console",
            description: descricao,
            color      : color,
            timestamp  : timestamp,
            thumbnail  : [url: "https://app.sommusgestor.com/App/Images/icone.png"],
            footer     : [text: "Jenkins - CI/CD"]
        ]]
    ]

    httpRequest(
        httpMode: 'POST',
        contentType: 'APPLICATION_JSON',
        requestBody: groovy.json.JsonOutput.toJson(payload),
        url: 'https://discord.com/api/webhooks/1283575763894796339/h9ODM5YOYr-1XYFSfmEQmYzBohEGeQztYP4LF2cDXBy1Y7G_0HRF-NusPh1xny3gKB73'
    )
}

def rgbToDecimalColor(int r, int g, int b) {
    return (r << 16) + (g << 8) + b
}
