pipeline{
    agent any
       tools{
        maven 'maven_3_8_6'
       }
       stages {
         stage("Build docker image"){
           steps{
             script {
                sh 'docker compose -f "docker-compose.yml" down '
                sh 'docker compose  -f "docker-compose.yml" up -d --build sqldata user '
             }
           }
         }
       }
 
}