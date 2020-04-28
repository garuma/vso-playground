FROM mcr.microsoft.com/vscode/devcontainers/base:ubuntu-18.04

# Avoid warnings by switching to noninteractive
ENV DEBIAN_FRONTEND=noninteractive
ENV DISPLAY=2
ENV USER=vscode

# Configure apt and install packages
RUN apt-get update \
    && apt-get -y install --no-install-recommends apt-utils dialog 2>&1 \
    #
    # Verify git, process tools, lsb-release (common in install instructions for CLIs) installed
    && apt-get -y install git openssh-client less iproute2 procps apt-transport-https gnupg2 curl lsb-release unzip \
    # Install Mono and dependencies
    && apt-get install -y --no-install-recommends gnupg ca-certificates \
    && apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF \
    && echo "deb https://download.mono-project.com/repo/ubuntu preview-bionic main" | sudo tee /etc/apt/sources.list.d/mono-official-preview.list \
    && apt-get update \
    && apt-get install -y --no-install-recommends mono-devel msbuild lxd monodoc-base nuget \
    && apt-get install -y --no-install-recommends ca-certificates-mono \
    # Install OpenJDK
    && wget -qO - https://adoptopenjdk.jfrog.io/adoptopenjdk/api/gpg/key/public | apt-key add - \
    && echo "deb https://adoptopenjdk.jfrog.io/adoptopenjdk/deb/ bionic main" | sudo tee /etc/apt/sources.list.d/adoptopenjdk.list \
    && apt-get update \
    && apt-get install -y --no-install-recommends adoptopenjdk-8-hotspot \
    ## Move to the user home directory at that stage
    && cd /home/vscode \
    # Install Android SDK
    && sudo -u vscode wget -O sdk-tools-linux.zip 'https://dl.google.com/android/repository/sdk-tools-linux-4333796.zip' \
    && sudo -u vscode unzip -q 'sdk-tools-linux.zip' -d android-sdk \
    && su -l -c "yes | /home/vscode/android-sdk/tools/bin/sdkmanager --licenses" vscode \
    && su -l -c "/home/vscode/android-sdk/tools/bin/sdkmanager --update && /home/vscode/android-sdk/tools/bin/sdkmanager \"emulator\" \"tools\" \"platform-tools\" \"build-tools;29.0.3\" \"platforms;android-28\" \"platforms;android-29\" \"system-images;android-29;google_apis_playstore;x86_64\"" vscode \
    && sudo -u vscode mkdir -p /home/vscode/.config/xbuild/ \
    && sudo -u vscode echo "<?xml version=\"1.0\" encoding=\"utf-8\"?><monodroid><android-sdk path=\"/home/vscode/android-sdk-macosx\" /><java-sdk /><android-ndk /></monodroid>" > /home/vscode/.config/xbuild/monodroid-config.xml \
    # Install Xamarin.Android
    && wget -q "https://neteril.org/~jeremie/xamarin.android-oss_10.2.99.180_amd64.deb" \
    && dpkg -i "xamarin.android-oss_10.2.99.180_amd64.deb" \
    # Create an emulator and start it up on a VNC server
    ## The command to start the VNC server: tightvncserver -geometry 1080x1920 -depth 24 :2
    ## to start the Android emulator: /home/vscode/android-sdk/emulator/emulator -avd default2 -qemu
    && apt-get install -y --no-install-recommends tightvncserver libnss3 libpulse0 xfonts-base libxcursor1 qemu-kvm libvirt-bin bridge-utils \
    && su -l -c 'printf "xamarin\nxamarin\n\n" | vncpasswd' vscode \
    && su -l -c "/home/vscode/android-sdk/tools/bin/avdmanager create avd -k \"system-images;android-29;google_apis_playstore;x86_64\" -d \"pixel\" --name \"default\"" vscode \
    #
    # Clean up
    && apt-get autoremove -y \
    && apt-get clean -y \
    && rm -rf /var/lib/apt/lists/*

ENV DEBIAN_FRONTEND=dialog