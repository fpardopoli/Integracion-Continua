pipeline{
    agent any
       stages {
         stage("Build docker image"){
           steps{
             script {
                bat 'docker compose -f "docker-compose.yml" down '
                bat 'docker compose  -f "docker-compose.yml" up -d --build sqldata user '
             }
           }
         }
       }
 
}