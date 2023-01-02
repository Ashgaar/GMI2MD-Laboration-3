# file: encode_cayennelpp_test.py
# https://github.com/smlng/pycayennelpp
# pip install pycayennelpp
# consult some CayenneLPP docs as:
# https://github.com/myDevicesIoT/cayenne-docs/blob/master/docs/LORA.md
# or the links in Learn
# Encoding
import binascii
from cayennelpp import LppFrame

# create empty Lppframe
frame = LppFrame()
# add some sensor data
frame.add_temperature(1, 27.2)
frame.add_humidity(2, 64.5)
frame.add_analog_output(3, 0.4)
frame.add_gps(4, 60.48726, 15.40954, 150)
# get byte buffer in CayenneLPP format
buffer = bytes(frame)
# will print the string / byte literal
# https://stackoverflow.com/questions/6269765/what-does-the-b-character-do-in-front-of-a-string-literal
print(f'LppFrame as bytes: {buffer}')
# to get the proper hexadecimal representation for C/C++/C#/...
# uint8_t tx_buffer[] = { 0x01, 0x67, ...};
print(f'Bytes for C: {binascii.hexlify(buffer)}')
print(f'Buffer len: {len(binascii.hexlify(buffer))/2}')
