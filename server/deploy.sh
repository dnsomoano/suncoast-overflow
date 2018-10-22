dotnet publish -c Release

cp dockerfile ./bin/release/netcoreapp2.1/publish

docker build -t suncoast-overflow-image ./bin/release/netcoreapp2.1/publish

docker tag suncoast-overflow-image registry.heroku.com/suncoast-overflow/web

docker push registry.heroku.com/suncoast-overflow/web

heroku container:release web -a suncoast-overflow

# sudo chmod 755 deploy.sh
# ./deploy.sh