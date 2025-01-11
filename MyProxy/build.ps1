# Get the current date and time in the format YYYYMMDDHHMM
$tag = (Get-Date -Format "yyyyMMddHHmm")

# Build the Docker image with the generated tag
docker build --platform linux/arm64 -t codemartlk/my-proxy:$tag .
docker push codemartlk/my-proxy:$tag