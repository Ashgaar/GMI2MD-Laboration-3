# file: decode_cayennelpp_test.py
# https://github.com/smlng/pycayennelpp
# pip install pycayennelpp
# consult some CayenneLPP docs as:
# https://github.com/myDevicesIoT/cayenne-docs/blob/master/docs/LORA.md
# or the links in Learn
# Decoding
from cayennelpp import LppFrame

# byte buffer in CayenneLPP format with 1 data item
# i.e. on channel 1, with a temperature of 25.5C
# buffer = bytearray([0x01, 0x67, 0x00, 0xff])

# do NOT use this byte array "hex codes" for C#, use binascii.hexlify()
# https://stackoverflow.com/questions/6269765/what-does-the-b-character-do-in-front-of-a-string-literal
buffer = bytearray(b'\x01g\x01\x10\x02h\x81\x03\x03\x00(\x04\x88\t:\xc8\x02Y\xef\x00:\x98')
# create Lppframe from bytes
frame = LppFrame().from_bytes(buffer)
# print the Lppframe and its data
print(frame)
